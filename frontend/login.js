const login = document.querySelector(".login-window");
const toast = document.querySelector(".toast");
let usernameInput = document.querySelector("#username");
let passwordInput = document.querySelector("#password");
let userInvalidAlert = document.querySelector(".invalid-feedback.username");
let passInvalidAlert = document.querySelector(".invalid-feedback.password");
[passwordInput,usernameInput].forEach(x=>{x.addEventListener("input",(event)=>{
    event.target.classList = "form-control";
})
}) 

login.addEventListener("submit",async function(event){
    event.preventDefault();
    let username = document.querySelector("#username").value;
    let password = document.querySelector("#password").value;
    try{
        let response = await fetch('http://localhost:5288/api/login',{
            method: "POST",
            headers: { 
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username: username,
                password: password
            })
        })
        let data = await response;
        switch (response.status) {
            case 500:
                document.querySelector(".me-auto").textContent = "Error";
                document.querySelector(".toast-body").textContent = data.split(" ").splice(0,2).join(" ");
                toast.classList.toggle("show");
                passInvalidAlert.textContent = "Oops something strange";
                passwordInput.classList.add("is-invalid");
                passwordInput.value = "";
                setTimeout(()=>{
                    toast.classList.toggle("show");
                },3000)
                break;
            case 200:
                document.querySelector(".me-auto").textContent = "Success";
                document.querySelector(".toast-body").textContent = "Authorized successfully";
                toast.classList.toggle("show");
                setTimeout(async ()=>{
                    toast.classList.toggle("show");
                    window.location.href = "http://localhost:5173";
                },3000);
                break;
            default:
                break;
        }
    }catch(error){
        console.log(error);
    }
})

