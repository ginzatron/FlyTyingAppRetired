const url = "https://localhost:44329/api";

const FlysButton = document.querySelector("#getFlys");
FlysButton.addEventListener('click', GetFlys);

const RegisterButton = document.querySelector("#register");
RegisterButton.addEventListener('click', Register);

const getFlyForm = document.querySelector(".getFlyForm");
getFlyForm.addEventListener('submit', GetFly)


async function Login() {
    const logInUrl = "/admin/login";

    const response = await fetch(url + logInUrl, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "email": "njginsburg@gmail.com",
            "password": "Test123!",
            "rememberMe": false
        })
    });

    const data = await response.json();
    console.log(data);
}

async function Register() {
    const registerUrl = "/admin/register";

    const response = await fetch(url + registerUrl, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "email": "ekginsburg@gmail.com",
            "password": "Test123!",
            "confirmPassword": "Test123!"
        })
    });

    const data = await response.json();
    console.log(data);

}

async function GetFlys() {
    const flyUrl = "/fly";
    const flyContainer = document.querySelector(".flyContainer");


    const response = await fetch(url + flyUrl);
    const data = await response.json();
    console.log(data);

    data.forEach(fly => {
        flyContainer.innerHTML += `<div>${fly.name} id:${fly.id}</div><div>${fly.classification.classification}</div>`
    })

}

async function GetFly(event) {
    event.preventDefault();
    const flyId = event.currentTarget.flyId.value;
    const flyUrl = `/fly/${flyId}`;

    const response = await fetch(url + flyUrl);
    const data = await response.json();
    console.log(data);
}

async function onSignIn(googleUser) {
    var id_token = googleUser.getAuthResponse().id_token;
    let url = "https://localhost:44329/api/admin/token";
    console.log(id_token);

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': 'Bearer ' + id_token
        },
        body: JSON.stringify({ "token": id_token })
    });
}

async function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });

    await fetch("https://localhost:44329/api/admin/logout", {
        method: "post",
        headers: {
            'Content-Type': 'application/json',
        }
    });
}