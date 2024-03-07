namespace UnitTestproject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TransactionConstructor_ValidAmountAndSufficientBalance_ShouldCreateTransaction()
        {
            // Arrange
            var fromAccount = new Account(1);
            fromAccount.Transaction(100.0);
            var toAccount = new Account(2);
            var amount = 50.0;

            // Act
            var transaction = new Transaction(fromAccount, toAccount, amount);

            // Assert
            Assert.AreEqual(amount, transaction.TransactionValue);
            Assert.AreEqual(fromAccount, transaction.From);
            Assert.AreEqual(toAccount, transaction.To);
        }

        [TestMethod]
        public void TransactionConstructor_NegativeAmount_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var fromAccount = new Account(1);
            fromAccount.Transaction(100.0);
            var toAccount = new Account(2);
            var amount = -50.0;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Transaction(fromAccount, toAccount, amount));
        }

        [TestMethod]
        public void TransactionConstructor_InsufficientBalance_ShouldThrowArgumentException()
        {
            // Arrange
            var fromAccount = new Account(1);
            fromAccount.Transaction(50.0);
            var toAccount = new Account(2);
            var amount = 100.0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Transaction(fromAccount, toAccount, amount));
        }
    }
}