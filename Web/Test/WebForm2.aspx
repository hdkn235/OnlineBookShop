<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="BookShop.Web.Test.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../imgareaselect/css/imgareaselect-default.css" rel="stylesheet" type="text/css" />
    <script src="../imgareaselect/scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../imgareaselect/scripts/jquery.imgareaselect.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#selectbanner').imgAreaSelect({
                handles: true
            });
        }); 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="../UpImages/1B1865417DCB20181A8A7BABCCFEF643.jpg" id="selectbanner" />
    </div>
    </form>
</body>
</html>
