using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFornecedor.Model;
using WebFornecedor.Service;

namespace WebFornecedor.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private int sellerId = 1;
        IApiService ApiClient = RestService.For<IApiService>("https://radiant-woodland-47818.herokuapp.com/");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            LimpaAlerta();
        }

        protected async void lkbVerResultadoLance_Click(Object sender, EventArgs e)
        {
            DateTime dataHoraLance = DateTime.Parse(hdnHoraLance.Value);
            TimeSpan tempoDoLance = DateTime.Now - dataHoraLance;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#modalBidResults').modal();", true);

            if (tempoDoLance.TotalMinutes <= 0.25)
            {
                lblModalResultadoDoLance.Text = "Aguarde " + (15 - tempoDoLance.Seconds) +
                    " segundos para saber o resultado do leilão";
            }
            else
            {
                var auctionResult = await ApiClient.GetResultadosBids(int.Parse(hdnLeilaoId.Value));
                var sellerObject = await ApiClient.GetSeller(auctionResult.SellerId);
                var auctionObject = await ApiClient.GetAuction(auctionResult.AuctionId);
                lblModalResultadoDoLance.Text = "O vencedor deste leilão foi: " + sellerObject.Name
                    + ". Lance de R$ " + auctionResult.Price;
                divResultadoLance.Visible = false;
                lkbUpdateEntregas.Visible = true;
                lkbDetalhesEntrega.Visible = true;

                PostAuctionClose put = new PostAuctionClose()
                {
                    ClientId = auctionObject.ClientId,
                    ProductId = auctionObject.ProductId,
                    Origin = auctionObject.Origin,
                    Destiny = auctionObject.Destiny,
                    DeliveryDate = auctionObject.DeliveryDate,
                    Status = "Finalizado"
                };
                await ApiClient.PutAuction(put, auctionResult.Id);
            }

        }

        protected async void lkbPostLance_Click(Object sender, EventArgs e)
        {
            await PostBid();
        }

        public async Task PostBid()
        {
            try
            {
                int auctionId = int.Parse(hdnLeilaoId.Value);
                PostAuction post = new PostAuction()
                {
                    SellerId = sellerId,
                    Price = double.Parse(txbValorLance.Text)
                };

                var bid = await ApiClient.PostAuction(post, auctionId);

                hdnHoraLance.Value = DateTime.Now.ToString();

                divResultadoLance.Visible = true;
                lkbUpdateEntregas.Visible = false;
                lkbDetalhesEntrega.Visible = false;
                lblResultadoLance.Text = "Leilão #" + bid.AuctionId + "- Lance #" +
                    bid.Id + "- Valor = R$" + bid.Price;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected async void lkbUpdateEntregas_Click(Object sender, EventArgs e)
        {
            await GetDados();
        }

        public async Task GetDados()
        {
            try
            {
                var auctions = await ApiClient.GetResponseAsync();

                var auctionsAtivas = auctions.Where(x => x.Status != "Finalizado").ToList();

                lbxEntregas.Items.Clear();
                foreach (var auction in auctionsAtivas)
                {
                    StringBuilder listItemSB = new StringBuilder();
                    listItemSB.Append("Leilão #");
                    listItemSB.Append(auction.Id);
                    string listItemString = listItemSB.ToString();

                    lbxEntregas.Items.Add(listItemString);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected void lkbDetalhesEntrega_Click(Object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lbxEntregas.SelectedValue))
                {
                    throw new ArgumentException("Favor selecionar alguma entrega");
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                var listLeilao = lbxEntregas.SelectedValue.Split('#').ToList();
                hdnLeilaoId.Value = listLeilao[listLeilao.Count - 1];
                PreencheModal();
            }
            catch (ArgumentException ex)
            {
                ExibeAlerta(ex.Message);
            }
            catch (Exception ex)
            {
                ExibeAlerta(ex.Message);
            }
        }

        public async void PreencheModal()
        {
            var auction = await ApiClient.GetAuction(int.Parse(hdnLeilaoId.Value));
            lblAuctionId.Text = "Leilão #" + hdnLeilaoId.Value;
            lblDataEntrega.Text = "Data entrega: " + auction.DeliveryDate.ToString("dd/MM/yyyy");
        }

        public void ExibeAlerta(string errorMsg)
        {
            alertaWarning.Visible = true;
            alertaWarning.InnerText = errorMsg;
        }

        public void LimpaAlerta()
        {
            alertaWarning.Visible = false;
        }
    }
}