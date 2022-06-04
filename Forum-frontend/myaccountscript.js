document.getElementById("logout-button").addEventListener("click", removeStoredInfo);

function removeStoredInfo() {
    sessionStorage.removeItem("Username");
    sessionStorage.removeItem("Password");
    localStorage.removeItem("myLoginToken");
    sessionStorage.removeItem("Id");
}
const myAuthToken = localStorage.getItem("myLoginToken");
const userId = sessionStorage.getItem("Id");
const updateUser = document.getElementById("update-user");
const deleteUser = document.getElementById("delete-user");
const showUser = document.getElementById("show-users");
const updatePost = document.getElementById("update-post");
const deletePost = document.getElementById("delete-post")

/* Listening for a submit event on the login form. When the submit event is triggered, it will call the
loginSubmit function. */
deleteUser.addEventListener("submit", function (event) {

    event.preventDefault();

});

async function deleteUserSubmit() {
    try {
        const deleteData = { "Id": userId };


        const URL = "https://localhost:44383/User/deleteUser?id=" + userId
        console.log(URL);

        await fetch(URL, {

            method: "DELETE",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(deleteData)

        }).then(response => response.json()

        ).then(jsonData => {

            sessionStorage.removeItem("Username");
            sessionStorage.removeItem("Password");
            localStorage.removeItem("myLoginToken");
            sessionStorage.removeItem("Id")
            window.location.href = "/login.html";

        }

        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }



}

updateUser.addEventListener("submit", function (event) {

    event.preventDefault();


});


async function updateUserSubmit() {

    var newFormUsername = document.getElementById("newUsername").value
    var newFormPassword = document.getElementById("newPassword").value
    console.log("Submit done");
    if (newFormPassword != null & newFormPassword != null) {
        await userUpdateRequest(newFormUsername, newFormPassword);
    }
}


async function userUpdateRequest(newFormUsername, newFormPassword) {
    try {
        const updateDataId = { "Id": userId };
        const updateInfo = {
            "username": newFormUsername,
            "password": newFormPassword
        }


        await fetch("https://localhost:44383/User/updateUser?id=" + userId, {

            method: "PATCH",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(updateInfo)

        }).then(response => response.json()

        ).then(jsonData => {
            sessionStorage.removeItem("Username");
            sessionStorage.removeItem("Password");
            localStorage.removeItem("myLoginToken");
            sessionStorage.removeItem("Id")
            window.location.href = "/login.html";

        }

        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }
}

showUser.addEventListener("submit", function (event) {
    event.preventDefault();

});



async function showUserSubmit(idSearch) {
    var idSearch = document.getElementById("searchUserId").value
    console.log("Search done"); try {
        await fetch("https://localhost:44383/User/getFromId?id=" + idSearch, {

            method: "GET",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },

        }).then(response => response.json()


        ).then(jsonData => {
            console.log(jsonData)

            const searchedUser = jsonData.username;

            alert("Username of the searched: " + searchedUser);

        }

        ).catch((e) => {
            console.error("Error:" + e);
            alert("User doesn't exist");
        }
        )

    } catch (e) {

        console.error("Error:" + e);

        alert("Error" + e);
    }
}

updatePost.addEventListener("submit", function (event) {

    event.preventDefault();


});


async function updatePostSubmit() {
    var postId = document.getElementById("titleId").value;
    var newTitle = document.getElementById("newTitle").value
    var newContent = document.getElementById("newContent").value
    console.log("Submit done");
    if (newContent != null & newTitle != null) {
        await updatePostRequest(postId, newTitle, newContent,);
    }
}


async function updatePostRequest(postId, newTitle, newContent) {

    try {
        const userSess = sessionStorage.getItem("Username");
        const passSess = sessionStorage.getItem("Password");
        const updatePost = {
            "id": postId,
            "title": newTitle,
            "content": newContent,
            "imageUrl": "no image chosen",
            "user": {
                "id": userId,
                "username": userSess,
                "password": passSess
            }
        };
        console.log(newTitle);

        await fetch("https://localhost:44383/Forumpost/updatePost?id=" + postId, {

            method: "PATCH",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(updatePost)

        }).then(response => response.json()

        ).then(jsonData => {
            
            window.location.href = "/index.html";

        }

        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }
}

deletePost.addEventListener("submit", function (event) {

    event.preventDefault();

});

async function deletePostSubmit() {
    var deletePostId = document.getElementById("deletePostId").value;
    console.log("Submit done");
    if (deletePostId != null ) {
        await deletePostRequest(deletePostId);
    }

}
async function deletePostRequest(deletePostId){
    try {

        await fetch("https://localhost:44383/Forumpost/deletePost?id=" + deletePostId, {

            method: "DELETE",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(deletePostId)

        }).then(response => response.json()

        ).then(jsonData => {

            window.location.href = "/index.html";

        }

        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }

}