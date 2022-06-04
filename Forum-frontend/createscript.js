const myAuthToken = localStorage.getItem("myLoginToken");
const userId = sessionStorage.getItem("Id");
const createPost = document.getElementById("createpost-form");
const sessionUsername = sessionStorage.getItem("Username");
const sessionPassword = sessionStorage.getItem("Password");
document.getElementById("logout-button").addEventListener("click", removeStoredInfo);

function removeStoredInfo() {
    sessionStorage.removeItem("Username");
    sessionStorage.removeItem("Password");
    localStorage.removeItem("myLoginToken");
    sessionStorage.removeItem("Id")
}
createPost.addEventListener("submit", function (event) {

    event.preventDefault();

});


async function createPostSubmit() {

    var postTitle = document.getElementById("title").value
    var postContent = document.getElementById("content").value

    console.log("Submit done");
    await createPostRequest(postTitle, postContent)

}

async function createPostRequest(postTitle, postContent) {
    try {
        const postInfoAndUser = {
            "title": postTitle,
            "content": postContent,
            "user": {
                "id": userId,
                "username": sessionUsername,
                "password": sessionPassword
            }
        }

        fetch("https://localhost:44383/Forumpost/createPost", {
            method: "POST",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"

            },
            body: JSON.stringify(postInfoAndUser)

        }).then(response => response.json()
        ).then(jsonData => {
            window.location.href = "/index.html";
        }
        )
    } catch (e) {

        console.error("Error:" + e);
    }

}