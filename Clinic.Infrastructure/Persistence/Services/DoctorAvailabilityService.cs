using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic.Infrastructure.Persistence.Services;

public class DoctorAvailabilityService(ClinicDbContext context)
    : IDoctorAvailabilityService
{
    private readonly ClinicDbContext _context = context;

    public async Task EnsureAvailabilityAsync(
        int doctorId,
        DateTime date,
        int requiredSlots,
        CancellationToken ct)
    {
        var shift = await _context.Set<Shift>()
            .SingleOrDefaultAsync(s =>
                s.DoctorId == doctorId &&
                s.Day == DateOnly.FromDateTime(date),
                ct);

        if (shift == null)
            throw new InvalidOperationException("No available Shift on date for the doctor");

        var bookedSlots = await _context.Set<Booking>()
            .Where(b =>
                b.DoctorId == doctorId &&
                b.OnDate.Date == date.Date)
            .SumAsync(b => b.DurationIn15MinSlots, ct);



        if(shift.Slot15Min - bookedSlots < requiredSlots)
            throw new InvalidOperationException("Not enough available slots for the requested doctor on the specified date.");

        //var overlappingAppointments = await _context.Query()
        //    .Where(a => a.DoctorId == doctorId &&
        //                ((appointmentStart >= a.StartTime && appointmentStart < a.EndTime) ||
        //                 (appointmentEnd > a.StartTime && appointmentEnd <= a.EndTime) ||
        //                 (appointmentStart <= a.StartTime && appointmentEnd >= a.EndTime)))
        //    .ToListAsync();

    }

    public async Task<List<DateTime>> GetAvailableSlotsAsync(
        int doctorId,
        DateOnly day,
        CancellationToken ct)
    {
        var shift = await _context.Set<Shift>()
            .SingleOrDefaultAsync(s =>
                s.DoctorId == doctorId &&
                s.Day == day,
                ct);

        if (shift == null) return [];

        var shiftStart = day.ToDateTime(TimeOnly.FromTimeSpan(shift.StartTime));

        // generate all shift slots
        var slots = Enumerable
            .Range(0, shift.Slot15Min)
            .Select(i => shiftStart.AddMinutes(i * 15))
            .ToList();

        // get bookings for the day
        var bookings = await _context.Set<Booking>()
            .Where(b =>
                b.DoctorId == doctorId &&
               DateOnly.FromDateTime( b.OnDate.Date) == day)
            .ToListAsync(ct);

        // expand bookings to occupied slots
        var bookedSlots = bookings
            .SelectMany(b =>
                Enumerable.Range(0, b.DurationIn15MinSlots)
                    .Select(i => b.OnDate.AddMinutes(i * 15)))
            .ToHashSet();

        // return free slots
        return slots
            .Where(s => !bookedSlots.Contains(s))
            .ToList();
    }
}