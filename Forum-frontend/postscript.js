var clicks = 0;
var hasClicked = false;

function onClick() {
    if (!hasClicked) {
        clicks += 1;
        document.getElementById("liked").innerHTML = clicks;
        hasClicked = true;
    }

};

var post = document.getElementById("post");
post.addEventListener("click", function () {
    var commentBoxValue = document.getElementById("comment-box").value;

    var li = document.createElement("li");
    var text = document.createTextNode(commentBoxValue);
    li.appendChild(text);
    document.getElementById("comment-content").appendChild(li);


});

document.getElementById("logout-button").addEventListener("click", removeStoredInfo);

function removeStoredInfo() {
    sessionStorage.removeItem("Username");
    sessionStorage.removeItem("Password");
    localStorage.removeItem("myLoginToken");
    sessionStorage.removeItem("Id");
}