<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutHeadImage.aspx.cs" Inherits="BookShop.Web.Member.CutHeadImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�������»������������� - �������80���𣬹�����99Ԫ���˷ѣ�</title>
    <meta content="�������»������������꣬�������ṩרҵ���������.���Ϲ���ѡ���»�������������(�������),��������б���.���������绰:010-65132842.010-65252592"
        name="description" />
    <meta content="��������� �»���� ������� ���Ϲ��� ����ͼ�����" name="keywords" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="../uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <link href="../imgareaselect/css/imgareaselect-default.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #divContent
        {
            float: left;
            border: solid 1px #ccc;
            background-color: #f0f0ee;
            width: 400px;
            height: 400px;
        }
        #divUpload
        {
            float: left;
            text-align: left;
            width: 780px;;
        }
        #file_upload
        {
            float: left;
        }
        #divRight
        {
            float: left;
            margin-top: 15px;
        }
        #divLeft
        {
            float: left;
            margin-top: 15px;
        }
        #divHead
        {
        	margin:20px auto auto 30px;
        	width:120px;
        	height:120px;
        	overflow:hidden;
        	position:relative;
        }
        #divCut
        {
        	border:1px solid white;
        	width:100px;
        	height:100px;
        }
    </style>
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <script src="../imgareaselect/scripts/jquery.imgareaselect.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var arr;
        $(function () {
            $('#file_upload').uploadify({
                'fileTypeDesc': 'Image Files',
                'fileTypeExts': '*.gif; *.jpg; *.png',
                'swf': '../uploadify/uploadify.swf',
                'uploader': '/ashx/Uploadify.ashx',
                'auto': true,
                'buttonText': 'ѡ��ͼƬ',
                'onUploadSuccess': function (file, data, response) {
                    arr = data.split(',');
                    if (arr[0] == 'ok') {
                        //$('#divContent').css('background', "#f0f0ee url(" + arr[1] + ") no-repeat center center");
                        $('#imgContent').attr('src', arr[1]).css({ 'visibility': 'visible', width: arr[2], height: arr[3] });
                        $('#btnSave').attr('disabled', false);
                    }
                    else if (arr[0] == 'error') {
                        alert(arr[1]);
                    }
                },
                'queueID': 'uploadfileQueue'
            });

            $('#btnSave').click(function () {
                var pic = $('#imgContent').attr('src');
                var x, y, w, h;
                $.post(
                  "/ashx/CutImage.ashx",
                  {
                      x: $('#imgContent').data('x'),
                      y: $('#imgContent').data('y'),
                      w: $('#imgContent').data('w'),
                      h: $('#imgContent').data('h'),
                      sizeW: '120',
                      sizeH: '120',
                      pic: pic
                  },
                  function (data) {
                      //�Ѳü���ͼƬ���ص�ԭ��
                      if (data) {
                          $('#imgHead').attr('src', data);
                      }
                  }
                );
            });

        });

        $(document).ready(function () {
            $('#imgContent').imgAreaSelect({
                aspectRatio: '1:1',
                handles: true,
                onSelectEnd: preview
            });
        });

        function preview(img, selection) {
            $('#imgContent').data('x', selection.x1);
            $('#imgContent').data('y', selection.y1);
            $('#imgContent').data('w', selection.width);
            $('#imgContent').data('h', selection.height);
        } 

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div class="top">
            <div class="m_c" style="width: 736px; height: 27px">
                <span class="l"><a href="http://www.beifabook.com" target="_blank">����ͼ��������վ</a> |&nbsp;
                    <a href="http://www.bjbb.com" target="_blank">����ͼ�����</a>&nbsp; | <a href="../default.aspx"
                        target="_blank"><font color="#00A0E9">���������</font></a>&nbsp;| <a href="http://www.zgcbb.com/"
                            target="_blank">�йش�ͼ�����</a>&nbsp; | <a href="http://www.yycbook.com/" target="_blank">
                                ���˴�ͼ�����</a>&nbsp; | <a href="http://www.hs-book.com" target="_blank">�������</a>&nbsp;
                    | <a href="/OrderInfo.aspx">�ҵĶ���</a></span></div>
        </div>
        <div style="width: 750px; text-align: left;">
            <img src="../images/������վ1.jpg" width="780" height="93" /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="clear: both; width: 750px;">
            <div id="divLeft">
                <div style="clear: left; text-align: left; font-size: 20; margin-bottom: 10px;">
                    <input style="font-size: 15;" type="button" id="btnSave" value="���в�����" disabled="disabled" />
                </div>
                <div id="divContent">
                    <img src="#" alt="����ͼƬ" style="visibility: hidden;" id="imgContent" />
                </div>
            </div>
            <div id="divRight">
                <div style="margin: 0px auto auto 30px; text-align: left;">
                    ��ǰͷ��</div>
                <div id="divHead">
                    <img src="../Images/header.jpg" alt="ͷ��" id="imgHead" />
                </div>
            </div>
            <div id="divUpload">
                <input type="file" name="file_upload" id="file_upload" />
                <span style="display: block; float: left; margin-top: 10px;">��ֻ���ϴ�����2M����png��jpg��gifͼƬ��</span>
            </div>
            <div id="uploadfileQueue">
            </div>
        </div>
        <div id="footer">
            <table border="0" width="100%" class="categories1">
                <tr>
                    <td align="center">
                        <ul>
                            <li><a href='#'>�����������������</li>
                            <li><a href="#">���Ӫҵʱ�䣺9��30-21��00 </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/images/logo123x40.jpg" width="123" height="40" border="0" /></a> <a href="#"
                                    target="_blank">
                                    <img border="0" src="/Images/kaixin.jpg" /></a> </li>
                            <li>&nbsp;<span lang="zh-cn"><a title="��ICP��08001692��" href="http://www.miibeian.gov.cn">��ICP��08987373��</a></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
    </center>
    </form>
</body>
</html>
