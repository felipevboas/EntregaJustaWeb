<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="EntregadorView.aspx.cs" Inherits="WebFornecedor.View.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="../lib/twitter-bootstrap/js/bootstrap.js"></script>
    <link href="../lib/twitter-bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
</head>
<body>

    <form id="Formulario" runat="server">

        <div class="alert alert-warning" role="alert" visible="false" runat="server" id="alertaWarning">
        </div>

        <asp:HiddenField ID="hdnLeilaoId" runat="server" />
        <asp:HiddenField ID="hdnHoraLance" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="row justify-content-md-center">
            <div class="col-md-auto">
                <h3>ENTREGA JUSTA</h3>
            </div>
        </div>

        <br />

        <div class="row justify-content-md-center">
            <div class="col-md-auto">
                <h4>Área do entregador</h4>
            </div>
        </div>

        <br />

        <div class="row justify-content-md-center">
            <div class="col-md-auto">
                <asp:ListBox
                    runat="server"
                    ID="lbxEntregas"
                    Rows="6"
                    Width="200px"
                    SelectionMode="Single"></asp:ListBox>
            </div>
        </div>

        <div class="row justify-content-md-center">
            <div class="col-md-auto">
                <asp:LinkButton class="btn btn-primary"
                    runat="server"
                    ID="lkbDetalhesEntrega"
                    OnClick="lkbDetalhesEntrega_Click">Detalhes da Entrega</asp:LinkButton>
            </div>
        </div>

        <br />

        <div class="row justify-content-md-center">
            <div class="col-md-auto">
                <asp:LinkButton class="btn btn-primary"
                    runat="server"
                    ID="lkbUpdateEntregas"
                    OnClick="lkbUpdateEntregas_Click">Atualiza Entregas</asp:LinkButton>
            </div>
        </div>

        <br />

        <div class="container" runat="server" id="divResultadoLance" visible="false">
            <div class="row justify-content-md-center">
                <div class="col-md-auto">                    
                    <asp:LinkButton class="btn btn-primary"
                        runat="server"
                        ID="lkbVerResultadoLance"
                        OnClick="lkbVerResultadoLance_Click">Ver Resultado do Lance</asp:LinkButton>                       
                </div>
            </div>
            <div class="row justify-content-md-center">
                <div class="col-md-auto">                     
                    <h5><asp:Literal ID="lblResultadoLance" runat="server"></asp:Literal></h5>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Detalhes da entrega</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <asp:Literal runat="server" ID="lblAuctionId"></asp:Literal>
                        </div>
                        <div class="row">
                            <asp:Literal runat="server" ID="lblDataEntrega"></asp:Literal>
                        </div>
                        <div class="row">
                            <label>Valor do Lance: </label>
                            <asp:TextBox runat="server" ID="txbValorLance"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton
                            runat="server"
                            class="btn btn-primary"
                            ID="lkbPostLance"
                            OnClick="lkbPostLance_Click">Fazer Lance</asp:LinkButton>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>

            </div>
        </div>

        <div class="modal fade" id="modalBidResults" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Informações do resultado</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <asp:Literal runat="server" ID="lblModalResultadoDoLance"></asp:Literal>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>

            </div>
        </div>


    </form>

</body>
</html>
