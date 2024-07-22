<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="StudentCourses.aspx.cs" Inherits="YunTech.StudentCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        *, ::after, ::before {
            box-sizing: border-box
        }

        button, input, optgroup, select, textarea {
            margin: 0;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit
        }

        [type=button], [type=reset], [type=submit], button {
            -webkit-appearance: button
        }
    </style>
    <link rel="canonical" href="https://getbootstrap.com/docs/5.3/examples/dashboard/" />



    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3" />

    <link href="Scripts/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.min.css" rel="stylesheet" />
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
                        <li class="nav-item"><a class="nav-link" href="./#">首頁</a></li>
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
        <h1 class="pb-2 border-bottom">學生選課資料</h1>
        <div>

            <form id="form1" runat="server">
                <div class="d-md-flex flex-md-equal my-md-6 ps-md-6">
                    <div class="input-group mb-3">

                        <h2 class="display-9">查詢學生
                        </h2>
                        <asp:TextBox ID="txSearch" class="w-25 p-2" runat="server"></asp:TextBox>

                        <asp:Button ID="BtnSearch" class="btn btn-outline-secondary" runat="server" Text="查詢" OnClick="BtnSearch_Click" />
                    </div>



                </div>
                <div class="d-md-flex flex-md-equal my-md-6 ps-md-6">
                    <div class="me-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center" style="width: auto; margin-right: auto;">
                        <div class="my-3 py-3">
                            <h2 class="display-8">學生資訊
                            </h2>
                        </div>
                        <asp:GridView ID="GvStud" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GvStud_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </div>
                    <div class="me-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center" style="width: auto; margin-right: auto;">
                        <div class="my-3 py-3">
                            <h2 class="display-8">選課資訊
                            </h2>
                        </div>




                        <p>
                            <asp:GridView ID="GvStudCourse" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </p>
                    </div>
                </div>



            </form>




        </div>
    </div>







</body>
</html>
