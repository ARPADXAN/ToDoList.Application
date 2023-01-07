const body = document.querySelector('body'),
      sidebar = body.querySelector('nav'),
      toggle = body.querySelector(".toggle"),
      searchBtn = body.querySelector(".search-box"),
      modeSwitch = body.querySelector(".toggle-switch"),
      modeText = body.querySelector(".mode-text");
toggle.addEventListener("click" , () =>{
    //justify-content: flex-start !important;
    let a = document.getElementsByClassName("todo-container")[0];
    a.style.justifyContent="flex-end";
    let b = document.getElementsByClassName("status")
    if(sidebar.classList[1] == "close"){
        console.log(b);  
        a.style.justifyContent="flex-end";
        for(i=0;i<b.length;i++){
            b[i].style.transform="scale(0.98)"
        }
        
    }
    else{
        a.style.justifyContent="center";
        for(i=0;i<b.length;i++){
            b[i].style.transform="scale(1)"
        }
    }
    sidebar.classList.toggle("close");
})

searchBtn.addEventListener("click" , () =>{
    sidebar.classList.remove("close");

})

modeSwitch.addEventListener("click" , () =>{
    body.classList.toggle("dark");
      let st = document.getElementsByClassName("status1");
    
    if(body.classList.contains("dark")){
        modeText.innerText = "حالت روز";
        for(i=0;i<st.length;i++){
            st[i].style.backgroundImage="repeating-linear-gradient(-45deg, transparent 0 10px, rgb(0, 0, 0) 10px 20px )"
        }
    }else{
        modeText.innerText = "حالت شب";
        for(i=0;i<st.length;i++){
            st[i].style.backgroundImage="repeating-linear-gradient(-45deg, rgb(0, 195, 255) 0 10px, rgb(255, 255, 255) 10px 15px )"
        }
        //dfl[pfell[s]]
    }
    
});