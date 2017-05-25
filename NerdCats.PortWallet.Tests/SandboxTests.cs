namespace NerdCats.PortWallet.Tests
{
    using NerdCats.PortWallet.Request;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SandboxTests
    {
        [Fact]
        public void TestWalletClientCreation()
        {
            // INFO: We must move this to a proper config loader. 
            var walletClient = new WalletClient(
                Constants.ApiSandboxBase,
                Constants.AppKey,
                Constants.SecretKey);

            Assert.NotNull(walletClient);
        }

        [Fact]
        public void TestWalletClientThrowsOnBadApiBase()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    null,
                    Constants.AppKey,
                    Constants.SecretKey);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    "",
                    Constants.AppKey,
                    Constants.SecretKey);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    " ",
                    Constants.AppKey,
                    Constants.SecretKey);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    "I am a bad url",
                    Constants.AppKey,
                    Constants.SecretKey);
            });
        }

        [Fact]
        public void TestWalletClientThrowsOnBadAppAndSecretKey()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    Constants.ApiSandboxBase,
                    null,
                    Constants.SecretKey);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    Constants.ApiSandboxBase,
                    " ",
                    Constants.SecretKey);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    Constants.ApiSandboxBase,
                    Constants.AppKey,
                    null);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var walletClient = new WalletClient(
                    Constants.ApiSandboxBase,
                    Constants.AppKey,
                    " ");
            });
        }

        [Fact]
        public async Task GenerateSampleInvoice()
        {
            var walletClient = new WalletClient(
                Constants.ApiSandboxBase,
                Constants.AppKey,
                Constants.SecretKey);

            var request = new InvoiceRequest()
            {
                address = "Sample address",
                zipcode = "1234",
                amount = 100,
                city = "Dhaka",
                state = "Dhaka",               
                email = "somebody@someemail.com",
                name = "Some Customer",
                phone = "+881234567890",
                product_name = "some product",
                product_description = "some product description",
                redirect_url = "http://test-merch.com/redirect",
                
            };

            WalletResponse<WalletInvoice> response 
                = await walletClient.GenerateInvoice(request);

            Assert.NotNull(response);
            Assert.True(response.status == ResponseStatus.ACCEPTED);
        }
    }
}
