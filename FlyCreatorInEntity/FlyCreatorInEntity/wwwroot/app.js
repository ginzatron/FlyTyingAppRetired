const url = "https://localhost:44329/api";

const FlysButton = document.querySelector("#getFlys");
FlysButton.addEventListener('click', GetFlys);

const createFlyForm = document.querySelector(".createFlyForm");
createFlyForm.addEventListener('submit', SaveFly);

async function GetFlys() {
    const flyUrl = "/fly";
    let flySidebar = document.querySelector(".flySidebar");

    const response = await fetch(url + flyUrl);
    const data = await response.json();

    data.forEach(fly => {
        flySidebar.innerHTML += `<div class="flyLink"><a href="/editfly.html?id=${fly.id}" class="flyName">${fly.name}</a></div>`
    })
}

async function SaveFly(event){
    event.preventDefault();
    const saveFlyUrl = "/fly";
    let flySidebar = document.querySelector(".flySidebar");
    let newFly = {
        name: event.currentTarget.name.value,
        flyclassificationid:  event.currentTarget.flyclassificationid.value
    };

    const response = await fetch(url+saveFlyUrl,{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newFly)
    });
    const data = await response.json();
    console.log(data);

    flySidebar.innerHTML += `<div class="flyName">${data.name}</div><div class="flyClass">${data.classification.classification}</div>`;
    //GetFlys();
}

async function PopulateClassification(){
    const classUrl = "/flyClassifications";
    const selectFields = document.querySelector('.flyClass');

    const response = await fetch(url + classUrl);
    data = await response.json();
    let options = data.map(option => `<option value=${option.id}>${option.classification}</option>`).join(' ');
    selectFields.innerHTML = options;
}

async function GetFly(event) {
    event.preventDefault();
    const flyId = event.currentTarget.flyId.value;
    const flyUrl = `/fly/${flyId}`;

    const response = await fetch(url + flyUrl);
    const data = await response.json();
    console.log(data);
}

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

 async function onSignIn(googleUser) {
    var id_token = googleUser.getAuthResponse().id_token;
    let url = "https://localhost:44329/api/admin/token";
    let flySidebar = document.querySelector(".flySidebar");

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': 'Bearer ' + id_token
        },
        body: JSON.stringify({ "Id_Token": id_token })
    });

    GetFlys();
    console.log("Logged in as: " + googleUser.getBasicProfile().getName());
}

 function onFailure(error) {
    console.log(error);
  }

function renderButton() {
    gapi.signin2.render("g-signin2", {
      scope: "profile email",
      width: 240,
      height: 50,
      longtitle: true,
      theme: "dark",
      onsuccess: onSignIn,
      onfailure: onFailure,
    });
  }

async function signOut() {
    let flySidebar = document.querySelector(".flySidebar");
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

    flySidebar.innerHTML = '';
}

PopulateClassification();
