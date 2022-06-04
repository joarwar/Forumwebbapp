
const loginForm = document.getElementById("register-form");


/* Listening for a submit event on the login form. When the submit event is triggered, it will call the
loginSubmit function. */
loginForm.addEventListener("submit", function (event) {

    event.preventDefault();

});


/**
 * When the user clicks the submit button, the function loginSubmit() is called. This function gets the
 * username and password from the form, and then calls the function postLoginRequest() with the
 * username and password as parameters.
 */
async function registerSubmit() {

    event.preventDefault();

    var formUsername = document.getElementById("username").value
    var formPassword = document.getElementById("password").value

    console.log("Submit done");

    await postRegisterRequest(formUsername, formPassword); 
}


async function postRegisterRequest(formUsername, formPassword) {
    try {
        const registerData = { "Username": formUsername, "Password": formPassword };


        const URL = "https://localhost:44383/User/createUser"
        console.log(URL);

        await fetch(URL, {

            method: "POST",
            headers: {
                "Content-type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "*",
                "Access-Control-Allow-Headers": "*"
            },
            body: JSON.stringify(registerData)

        }).then(response => response.json()

        ).then(jsonData => {

            window.location.href = "/login.html";
            console.log(jsonData)
            
        }
        
        ).catch((e) => {
            console.error("Error:" + e);
        }
        )

    } catch (e) {

        console.error("Error:" + e);
    }



}
