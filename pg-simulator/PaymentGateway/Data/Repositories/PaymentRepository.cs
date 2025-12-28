using PaymentGateway.Data;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Shared.Models;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _db;
    public PaymentRepository(ApplicationDbContext db) => _db = db;

    public async Task AddPaymentAsync(PaymentTransaction txn)
    {
        _db.Payments.Add(txn);
        await _db.SaveChangesAsync();
    }

    public async Task<PaymentTransaction?> GetPaymentByIdAsync(string transactionId)
        => await _db.Payments.FirstOrDefaultAsync(p => p.TransactionId == transactionId);

    public async Task UpdatePaymentAsync(PaymentTransaction txn)
    {
        _db.Payments.Update(txn);
        await _db.SaveChangesAsync();
    }

    public async Task AddRefundAsync(RefundTransaction refund)
    {
        _db.Refunds.Add(refund);
        await _db.SaveChangesAsync();
    }

    public async Task<RefundTransaction?> GetRefundByIdAsync(string refundId)
        => await _db.Refunds.FirstOrDefaultAsync(r => r.RefundId == refundId);
}
