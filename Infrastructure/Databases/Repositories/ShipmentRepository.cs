using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.Repositories;

public class ShipmentRepository(DataContext context) : IShipmentRepository
{
    private readonly DataContext _context = context;

    public async Task<ICollection<Shipment>> All()
    {
        return await _context.Shipments.OrderBy(p => p.Id).ToListAsync();
    }

    public Shipment Get(int id)
    {
        return _context.Shipments.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Shipment not found");
    }

    public async Task<int> Create(Shipment shipment, CancellationToken cancellationToken)
    {
        await _context.Shipments.AddAsync(shipment, cancellationToken);
        _context.SaveChanges();

        return shipment.Id;
    }

    public async Task Update(Shipment shipment, CancellationToken cancellationToken)
    {
        _context.Shipments.Update(shipment);
         await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Shipment shipment, CancellationToken cancellationToken)
    {
        _context.Shipments.Remove(shipment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}