const toast = document.querySelector(".toast");
let usernameInput = document.querySelector("#username");
let passwordInput = document.querySelector("#password");
let userInvalidAlert = document.querySelector(".invalid-feedback.username");
let passInvalidAlert = document.querySelector(".invalid-feedback.password");
[passwordInput,usernameInput].forEach(x=>{x.addEventListener("input",(event)=>{
    event.target.classList = "form-control";
})
}) 

document.querySelector(".registration-window").addEventListener("submit",async function(event){
    event.preventDefault();
    let username = document.querySelector("#username").value;
    let password = document.querySelector("#password").value;
    let email = document.querySelector("#email").value;
    let city = document.querySelector("#address").value;
    if(password==document.querySelector("#repetition").value){
        try{
            let response = await fetch('http://localhost:5288/api/register',{
                method: "POST",
                headers: { 
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    username: username,
                    password: password,
                    email: email,
                    cities: city
                })
            })
            let data = await response;
            console.log(data)
            switch (response.status) {
                case 500:
                    userInvalidAlert.textContent = data;
                    usernameInput.classList.add("is-invalid");
                    break;
                case 404:
                    userInvalidAlert.textContent = data;
                    usernameInput.classList.add("is-invalid");
                    break;
                case 200:
                    document.querySelector(".me-auto").textContent = "Success";
                    document.querySelector(".toast-body").textContent = `Successfully registered`;
                    setTimeout(()=>{
                    toast.classList.toggle("show");
                    window.location.href = "http://localhost:5173/login.html"
                    },1500);
                    break;
                default:
                    break;
            }
        }catch(error){
            console.log(error)
                    }
    }else{
        document.querySelector(".me-auto").textContent = "Error";
        document.querySelector(".toast-body").textContent = "Password doesn`t match with confirmation!"
        toast.classList.toggle("show");
        setTimeout(()=>toast.classList.toggle("show"),3000);
    } 
})

