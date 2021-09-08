$(function () {
    var timerVar;
    var pId;
    var isActive;
     function chatstart () {
        $('#chatModal').modal('show');
        timerVar;
        clearInterval(timerVar);
        timerVar = setInterval(countTimer, 1000);
        var totalSeconds = 0;
        function countTimer() {
            ++totalSeconds;
            var hour = Math.floor(totalSeconds / 3600);
            var minute = Math.floor((totalSeconds - hour * 3600) / 60);
            var seconds = totalSeconds - (hour * 3600 + minute * 60);
            if (hour < 10)
                hour = "0" + hour;
            if (minute < 10)
                minute = "0" + minute;
            if (seconds < 10)
                seconds = "0" + seconds;
            document.getElementById("timer").innerHTML = hour + ":" + minute + ":" + seconds;
        }
    };
    // Declare a proxy to reference the hub.
    var chatHub = $.connection.chatHub;
    registerClientMethods(chatHub);
    // Start Hub
    $.connection.hub.start().done(function () {

        registerEvents(chatHub)

    });

    // Reset Message Counter on Hover
    $("#divChatWindow").mouseover(function () {

        $("#MsgCountMain").html('0');
        $("#MsgCountMain").attr("title", '0 New Messages');
    });



    // Stop Title Alert
    window.onfocus = function (event) {
        if (event.explicitOriginalTarget === window) {

            clearInterval(IntervalVal);
            //document.title = 'SignalR Chat App';
        }
    }
    // Show Title Alert
    //function ShowTitleAlert(newMessageTitle, pageTitle) {
    //    if (document.title == pageTitle) {
    //        document.title = newMessageTitle;
    //    }
    //    else {
    //        document.title = pageTitle;
    //    }
    //}

    function registerEvents(chatHub) {

        var name = $("#hdnFullName").val();
        var custid = $("#hdnsession").val();
        debugger
        if (name.length > 0) {
            chatHub.server.connect(name, custid);

        }


        // Clear Chat
        $('#btnClearChat').click(function () {

            var msg = $("#divChatWindow").html();

            if (msg.length > 0) {
                chatHub.server.clearTimeout();
                $('#divChatWindow').html('');

            }
        });

        // Send Button Click Event

        $('#btnSendMsg').click(function () {
            var msg = $("#txtMessage").val();

            if (msg.length > 0) {

                var userName = $('#hdUserName').val();
                var userId = $('#hdId').val();
                //pId = $('#CustID').val();
                var date = GetCurrentDateTime(new Date());
                chatHub.server.sendPrivateMessage(userId, pId, msg);
                /*chatHub.server.sendMessageToAll(userName, msg, date);*/
                $("#txtMessage").val('');
            }
        });
        //$('#btnSendMsg').click(function () {
        //    var msg = $("#txtMessage").val();

        //    if (msg.length > 0) {

        //        var userName = $('#hdUserName').val();

        //        var date = GetCurrentDateTime(new Date());

        //        chatHub.server.sendMessageToAll(userName, msg, date);
        //        $("#txtMessage").val('');
        //    }
        //});

        // Send Message on Enter Button
        $("#txtMessage").keypress(function (e) {

            if (e.which == 13) {
                e.preventDefault();
                $('#btnSendMsg').click();
            }
        });

    }

    function registerClientMethods(chatHub) {


        // Calls when user successfully logged in
        chatHub.client.onConnected = function (id, userName, allUsers, messages, times) {

            $('#hdId').val(id);
            $('#hdUserName').val(userName);
            $('#spanUser').html(userName);

            // Add All Users
            //for (i = 0; i < allUsers.length; i++) {

            //    AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName, allUsers[i].UserImage, allUsers[i].LoginTime);
            //}

            // Add Existing Messages
            for (i = 0; i < messages.length; i++) {
                AddMessage(messages[i].UserName, messages[i].Message, messages[i].Time, messages[i].UserImage);

            }
        }

        // On New User Connected
        //chatHub.client.onNewUserConnected = function (id, name, UserImage, loginDate) {
        //    AddUser(chatHub, id, name, UserImage, loginDate);
        //}

        // On User Disconnected
        chatHub.client.onUserDisconnected = function (id, userName) {

            $('#Div' + id).remove();

            var ctrId = 'private_' + id;
            $('#' + ctrId).remove();


            var disc = $('<div class="disconnect">"' + userName + '" logged off.</div>');

            $(disc).hide();
            $('#divusers').prepend(disc);
            $(disc).fadeIn(200).delay(2000).fadeOut(200);

        }

        chatHub.client.messageReceived = function (userName, message, time, userimg) {

            AddMessage(userName, message, time, userimg);

            // Display Message Count and Notification
            var CurrUser1 = $('#hdUserName').val();
            if (CurrUser1 != userName) {

                var msgcount = $('#MsgCountMain').html();
                msgcount++;
                $("#MsgCountMain").html(msgcount);
                $("#MsgCountMain").attr("title", msgcount + ' New Messages');
                var Notification = 'New Message From ' + userName;
                IntervalVal = setInterval("ShowTitleAlert('SignalR Chat App', '" + Notification + "')", 800);

            }
        }


        chatHub.client.sendPrivateMessage = function (windowId, pid, fromUserName, message, userimg, CurrentDateTime) {
            if (isActive !== "true") {
                if (confirm(' ' + fromUserName + ' want to start the chat with you?')) {
                    isActive = "true";
                    debugger;
                    chatHub.server.notifyPandit(pid);
                    chatstart();
                } else {
                    // Do nothing!
                }
            }
          

            AddMessage(fromUserName, message, CurrentDateTime, userimg);
            pId = pid;
            $('#hdId').val(windowId);
            // Display Message Count and Notification
            var CurrUser1 = $('#hdnFullName').val();
            if (CurrUser1 != fromUserName) {

                var msgcount = $('#MsgCountMain').html();
                msgcount++;
                $("#MsgCountMain").html(msgcount);
                $("#MsgCountMain").attr("title", msgcount + ' New Messages');
                var Notification = 'New Message From ' + fromUserName;
                IntervalVal = setInterval("ShowTitleAlert('SignalR Chat App', '" + Notification + "')", 800);

            }
        }

    }

    function GetCurrentDateTime(now) {

        var localdate = dateFormat(now, "dddd, mmmm dS, yyyy, h:MM:ss TT");

        return localdate;
    }

    

    function AddMessage(userName, message, time, userimg) {
        var CurrUser = $('#hdnFullName').val();
        var Side = 'right';
        var TimeSide = 'left';

        if (CurrUser == userName) {
            Side = 'left';
            TimeSide = 'right';

        }
        var divChat = '<div class="direct-chat-msg ' + Side + '">' +
            '<div class="direct-chat-info clearfix">' +
            '<span class="direct-chat-name pull-' + Side + '">' + userName + '</span>' +
            '<span class="direct-chat-timestamp pull-' + TimeSide + '"">' + time + '</span>' +
            '</div>' +

            ' <img class="direct-chat-img" src="https://bootdey.com/img/Content/user_1.jpg" alt="Message User Image">' +
            ' <div class="direct-chat-text" >' + message + '</div> </div>';

   
        $('.direct-chat-messages').append(divChat);
        
        $('#divChatWindow')[0].scrollTop = $('#divChatWindow')[0].scrollHeight

    }


});