
const loginForm = document.getElementById("login-form");
var usernameValue = document.getElementById("username").value


/* Listening for a submit event on the login form. When the submit event is triggered, it will call the
loginSubmit function. */
loginForm.addEventListener("submit", function (event) {

    event.preventDefault();
    loginSubmit();

});

const baseURL = " localhost:44383/";

/**
 * When the user clicks the submit button, the function loginSubmit() is called. This function gets the
 * username and password from the form, and then calls the function postLoginRequest() with the
 * username and password as parameters.
 */
async function loginSubmit() {

    event.preventDefault();

    var formUsername = document.getElementById("username").value
    var formPassword = document.getElementById("password").value

    console.log("Submit done");

    await postLoginRequest(formUsername, formPassword); 
}


async function postLoginRequest(formUsername, formPassword) {
    try {
        const postData = { "Username": formUsername, "Password": formPassword };


        const URL = "https://localhost:44383/User/authUser"
        console.log(URL);

        await fetch(URL, {

            method: "POST",
            headers: {
                "Content-type": "application/json",
                "Authorization": localStorage.getItem("myLoginToken"),
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(postData)

        }).then(response => response.json()

        ).then(jsonData => {

            console.log("Answer" + jsonData.token);

            var returnedToken = jsonData.token;
            const userId = jsonData.id
            localStorage.setItem("myLoginToken", returnedToken);
            window.location.href = "/index.html";
            sessionStorage.setItem("Username", formUsername);
            sessionStorage.setItem("Password", formPassword);
            sessionStorage.setItem("Id", userId);
            console.log(jsonData.id)
            
        }
        
        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }



}

// getContent();


// function getContent() {
    
//     console.log("")
//     console.log("https://localhost:44383/User/authUser");


//     fetch("https://localhost:44383/Forumpost/getPost", {
//         method: "GET",
//         headers: {
//             "Content-type": "application/json",
//             "Authorization": localStorage.getItem("myLoginToken"),
//             "Access-Control-Allow-Origin": "*",
//             "Access-Control-Allow-Methods": "*",
//             "Access-Control-Allow-Headers": "*"

//         },



//     }).then(response => response.json()
//     ).then(jsonData => {

//         var errorMessage = jsonData.Username;

//         console.log(errorMessage);

//         document.getElementById("error-message").innerText = errorMessage;

//     }





//     ).catch((errorMessage) => {

//         console.error("Error:" + errorMessage);
//         var errorMessage = jsonData.message;
//         console.log(errorMessage);
//         document.getElementById("error-message").innerText = errorMessage;
//     })


// }





