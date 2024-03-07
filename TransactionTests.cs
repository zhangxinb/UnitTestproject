using NUnit.Framework;

[TestFixture]
public class TransactionTests
{
    [Test]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenTransferValueIsNegative()
    {
        // Arrange
        var fromAccount = new Account(1, 1000);
        var toAccount = new Account(2, 1000);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Transaction(fromAccount, toAccount, -100));
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenFromAccountBalanceIsTooLow()
    {
        // Arrange
        var fromAccount = new Account(1, 100);
        var toAccount = new Account(2, 1000);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Transaction(fromAccount, toAccount, 200));
    }

    [Test]
    public void Constructor_SuccessfullyTransfers_WhenFromAccountBalanceIsSufficient()
    {
        // Arrange
        var fromAccount = new Account(1, 1000);
        var toAccount = new Account(2, 1000);
        var transferValue = 200;

        // Act
        var transaction = new Transaction(fromAccount, toAccount, transferValue);

        // Assert
        Assert.AreEqual(fromAccount.Balance, 1000 - transferValue);
        Assert.AreEqual(toAccount.Balance, 1000 + transferValue);
    }
}
