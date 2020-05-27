const url = "https://localhost:44329/api";

const getFlysButton = document.querySelector("#getFlys");
getFlysButton.addEventListener('click',GetFlys);

const getFlyButton = document.querySelector("#getFly");
getFlyButton.addEventListener('click',GetFly);



async function GetFlys(){
    const flyUrl = "/fly";

    const response = await fetch(url+flyUrl);
    const data = await response.json();
    console.log(data);
}

async function GetFly(id="11"){
    const flyUrl = `/fly/11`;

    const response = await fetch(url+flyUrl);
    const data =await response.json();
    console.log(data);
}