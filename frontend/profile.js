async function init(){
    let request = await fetch('http://localhost:5288/api/profile',{
        method:"POST",
        headers: { 
            "Content-Type": "application/json"
        },
        body:`${localStorage.getItem("user")}`
        
    })
    let data = await request.json();
    document.querySelector(".name").textContent += data.username
    document.querySelector(".city").textContent += data.cities
    document.querySelector(".email").textContent += data.email
    

    // <div class="name">23123</div>
    //               <div class="email">213123</div>
    //               <div class="city">213123</div>
    //               <div class="rankProf">123123</div>
}
init()