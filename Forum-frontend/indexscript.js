window.onload = getMultipleContent();
const idText ="id: ";
let sessionName = sessionStorage.getItem("Username");

var d = new Date(),
    month = d.getMonth() + 1,
    day = (d.getDate() < 10) ? "0" + d.getDate() : d.getDate(),
    year = d.getFullYear(),
    hours = d.getHours(),
    minutes = d.getMinutes(),
    seconds = (d.getSeconds() < 10) ? "0" + d.getSeconds() : d.getSeconds();

if (hours > 12) {
    hours -= 12;
} else if (hours === 0) {
    hours = 12;
}

var today = hours + ":" + minutes + ":" + seconds + " " + month + "/" + day + "/" + year;

if(sessionName != null){
    document.getElementById("login-button").style.visibility = "hidden";
    document.getElementById("logout-button").style.visibility = "block";
    document.getElementById("create-button").style.visibility = "block";
    document.getElementById("user-button").style.visibility = "block";
    document.getElementById("register-button").style.visibility = "hidden";
}

else{
    document.getElementById("login-button").style.visibility = "block";
    document.getElementById("logout-button").style.visibility = "hidden";
    document.getElementById("create-button").style.visibility = "hidden";
    document.getElementById("user-button").style.visibility = "hidden";
    document.getElementById("register-button").style.visibility = "block";
}

document.getElementById("logout-button").addEventListener("click", removeStoredInfo);

function removeStoredInfo() {
    sessionStorage.removeItem("Username");
    sessionStorage.removeItem("Password");
    localStorage.removeItem("myLoginToken");
    sessionStorage.removeItem("Id");
}


function getMultipleContent() {

    fetch("https://localhost:44383/Forumpost/getPost", {

        method: "GET",
        headers: {
            "Content-type": "application/json",
            "Authorization": localStorage.getItem("myLoginToken"),
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "*",
            "Access-Control-Allow-Headers": "*"

        },
        


    })
        .then(response => response.json()
        ).then(jsonData => {

            console.log(jsonData);
            const errorMessage = jsonData.message;

            for (var forumPost in jsonData) {
                console.log (jsonData[forumPost])
                const numberPost = document.createElement("p");
                const newTitle = document.createElement("h4");
                const newContent = document.createElement("p");
                const newTimePost = document.createElement("p");       

                const newComment = document.createElement("textarea");
                newComment.setAttribute("id","comment-box");

                const newCommentButton = document.createElement("button");
                newComment.setAttribute("id","post");

                const newLikeCounter = document.createElement("p");
                newLikeCounter.setAttribute("id","like-counter");

                const newLiked = document.createElement("p");
                const newBorder = document.createElement("p");

                newCommentButton.appendChild(document.createElement("button"));
                newComment.appendChild(document.createElement("textarea"));
                newLiked.appendChild(document.createTextNode("0"));
                newBorder.appendChild(document.createTextNode("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"));
                newTimePost.appendChild(document.createTextNode(jsonData[forumPost].timePosted));
                newTitle.appendChild(document.createTextNode(jsonData[forumPost].title));
                newContent.appendChild(document.createTextNode(jsonData[forumPost].content));
                numberPost.appendChild(document.createTextNode(jsonData[forumPost].id));
                // newLikeCounter.appendChild(document.createTextNode("Like"));
                document.getElementById("forum-posts").appendChild( numberPost);
                document.getElementById("forum-posts").appendChild(newTitle);
                document.getElementById("forum-posts").appendChild(newContent);
                document.getElementById("forum-posts").appendChild(newTimePost);
                // document.getElementById("forum-posts").appendChild(newLikeCounter);
                // document.getElementById("forum-posts").appendChild(newLiked);
                // document.getElementById("forum-posts").appendChild(newComment);
                // document.getElementById("forum-posts").appendChild(newCommentButton);

                document.getElementById("forum-posts").appendChild(newBorder);
                



            }

        }


        ).catch((errorMessage) => {
            console.error("Error:" +errorMessage);
            var errorMessage = jsonData.title;
            console.log(errorMessage);
    
            document.getElementById("error-message").innerText = errorMessage;

        }

        )


}

// var clicks = 0;
// var hasClicked = false;

// function onClick() {
//     if (!hasClicked) {
//         clicks += 1;
//         document.getElementById("liked").innerHTML = clicks;
//         hasClicked = true;
//     }

// };

// var post = document.getElementById("post");
// post.addEventListener("click", function () {
//     var commentBoxValue = document.getElementById("comment-box").value;

//     var li = document.createElement("li");
//     var text = document.createTextNode(commentBoxValue);
//     li.appendChild(text);
    
//     var liDate = document.createElement("li")
//     var todayDate = document.createTextNode(today);
//     liDate.appendChild(todayDate);
//     document.getElementById("one-comment").appendChild(liDate);
//     document.getElementById("one-comment").appendChild(li);



// });

