var userName = prompt("Введите имя: ");
var chat = $.connection.chatHub;


chat.client.messageReceived = function (userName, message) {
    $("#messages").append('<li><strong>' + userName + '</strong>: ' + message);
};

chat.client.getOnlineUsers = function (userList) {
    $("#userList").empty();
    for (var i = 0; i < userList.length; i++)
        addUser(userList[i]);
};

chat.client.newUserAdded = function (newUser) {
    addUser(newUser);
}

$("#messageBox").focus();

$("#sendMessage").click(function () {
    if($("#messageBox").val().trim()!==""){
        chat.server.send(userName, $("#messageBox").val());
        $("#messageBox").val("");
        $("#messageBox").focus();
    }
});

$("#messageBox").keyup(function (event) {
    if (event.keyCode == 13)
        $("#sendMessage").click();
});

function addUser(user){
    $("#userList").append('<li class="list-group-item">' + user + '</li>');
}

$.connection.hub.logging = true;
$.connection.hub.start().done(function () {
    chat.server.connect(userName);
});

window.onbeforeunload = function(e){
    chat.server.disconnect(userName);
    $.connection.hub.end();
}
