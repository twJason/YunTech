<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="YunTech.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
    <link rel="canonical" href="https://getbootstrap.com/docs/5.3/examples/dashboard/" />



    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3" />

    <link href="Scripts/bootstrap.min.css" rel="stylesheet" />
    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }

        .b-example-divider {
            width: 100%;
            height: 3rem;
            background-color: rgba(0, 0, 0, .1);
            border: solid rgba(0, 0, 0, .15);
            border-width: 1px 0;
            box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15);
        }

        .b-example-vr {
            flex-shrink: 0;
            width: 1.5rem;
            height: 100vh;
        }

        .bi {
            vertical-align: -.125em;
            fill: currentColor;
        }

        .nav-scroller {
            position: relative;
            z-index: 2;
            height: 2.75rem;
            overflow-y: hidden;
        }

            .nav-scroller .nav {
                display: flex;
                flex-wrap: nowrap;
                padding-bottom: 1rem;
                margin-top: -1px;
                overflow-x: auto;
                text-align: center;
                white-space: nowrap;
                -webkit-overflow-scrolling: touch;
            }

        .btn-bd-primary {
            --bd-violet-bg: #712cf9;
            --bd-violet-rgb: 112.520718, 44.062154, 249.437846;
            --bs-btn-font-weight: 600;
            --bs-btn-color: var(--bs-white);
            --bs-btn-bg: var(--bd-violet-bg);
            --bs-btn-border-color: var(--bd-violet-bg);
            --bs-btn-hover-color: var(--bs-white);
            --bs-btn-hover-bg: #6528e0;
            --bs-btn-hover-border-color: #6528e0;
            --bs-btn-focus-shadow-rgb: var(--bd-violet-rgb);
            --bs-btn-active-color: var(--bs-btn-hover-color);
            --bs-btn-active-bg: #5a23c8;
            --bs-btn-active-border-color: #5a23c8;
        }

        .bd-mode-toggle {
            z-index: 1500;
        }

            .bd-mode-toggle .dropdown-menu .active .bi {
                display: block !important;
            }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
</head>
<body>

    <nav class="navbar navbar-expand-md bg-dark sticky-top border-bottom" data-bs-theme="dark">
        <div class="container">
            <a class="navbar-brand d-md-none" href="#">
                <svg class="bi" width="24" height="24">
                    <use xlink:href="#aperture" />
                </svg>
                Aperture
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvas" aria-controls="offcanvas" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvas" aria-labelledby="offcanvasLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasLabel">Aperture</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <ul class="navbar-nav flex-grow-1 justify-content-between">
                        <li class="nav-item"><a class="nav-link" href="#">
                            <svg class="bi" width="24" height="24">
                                <use xlink:href="#aperture" />
                            </svg>
                        </a></li>
                        <li class="nav-item"><a class="nav-link" href="#">首頁</a></li>
                        <li class="nav-item"><a class="nav-link" href="./Students">學生學籍資料</a></li>
                        <li class="nav-item"><a class="nav-link" href="/StudentCourses">學生選課資料</a></li>
                        <svg class="bi" width="24" height="24">
                            <use xlink:href="#cart" />
                        </svg>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
    <div class="container px-4 py-5" id="featured-3">
        <h1 class="pb-2 border-bottom">學生學籍資料</h1>
        <div>

            <form id="form1" runat="server">

                <div class="d-md-flex flex-md-equal my-md-6 ps-md-6">
                    <div class="me-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center" style="width: auto; margin-right: auto;">
                        <div class="my-3 py-3">
                            <h2 class="display-8">學生查詢
                            </h2>
                        </div>

                        <asp:Label ID="LbSearch" runat="server" Text="查詢"></asp:Label>
                        <asp:TextBox ID="txSearch" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="查詢" OnClick="BtnSearch_Click" />


                        <br />

                        <br />
                        <asp:GridView ID="GvStud" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvStud_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                    <div class="me-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center ">
                        <div class="my-3 p-3">
                            <h2 class="display-85">學生詳細資訊</h2>

                            <table class="table table-borderless">
                                <thead>
                                    <tr>
                                        <th scope="col"></th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="LbNo" runat="server" Text="學號"></asp:Label></th>
                                        <td>
                                            <asp:TextBox ID="TxNo" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label></th>
                                        <td>
                                            <asp:TextBox ID="TxName" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="Label2" runat="server" Text="性別"></asp:Label></th>
                                        <td>
                                            <asp:RadioButtonList ID="RbSex" runat="server">
                                                <asp:ListItem Selected="True" >男</asp:ListItem>
                                                <asp:ListItem  >女</asp:ListItem>
                                            </asp:RadioButtonList>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="Label3" runat="server" Text="科系"></asp:Label>
                                        </th>
                                        <td>
                                                <asp:DropDownList ID="DlDept" class="dropdown-menu position-static d-grid gap-1 p-2 rounded-3 mx-0 shadow w-220px" data-bs-theme="light" runat="server" OnSelectedIndexChanged="DlDept_SelectedIndexChanged">
                                                </asp:DropDownList>                                         
                                            <asp:Label ID="LbDept" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="Label4" runat="server" Text="電話"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="TxTel" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label ID="Label5" runat="server" Text="地址"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="TxAdd" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>

                                </tbody>
                            </table>











                            <div>

                                <asp:Button ID="BtnAdd" class="btn btn-info rounded-pill px-3" runat="server" Text="新增" OnClick="BtnAdd_Click" />

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
           <asp:Button ID="BtnUpdate" class="btn btn-info rounded-pill px-3" runat="server" Text="修改" OnClick="BtnUpdate_Click" />

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="BtnDel" class="btn btn-danger rounded-pill px-3" runat="server" Text="刪除" OnClick="BtnDel_Click" />

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="BtnClear" class="btn btn-light rounded-pill px-3" runat="server" Text="清除" OnClick="BtnDel_Click" />
                            </div>
                        </div>


                    </div>
                </div>








            </form>

        </div>
    </div>






</body>
</html>
