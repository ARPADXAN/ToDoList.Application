const todos = document.querySelectorAll(".todo");
const all_status = document.querySelectorAll(".status");
let draggableTodo = null;

todos.forEach((todo) => {
    todo.addEventListener("dragstart", dragStart);
    todo.addEventListener("dragend", dragEnd);
});

function dragStart() {
    draggableTodo = this;
    setTimeout(() => {
        this.style.display = "none";
    }, 0);
    console.log("dragStart");
}

function dragEnd() {
    draggableTodo = null;
    setTimeout(() => {
        this.style.display = "block";
    }, 0);
    console.log("dragEnd");
}

all_status.forEach((status) => {
    status.addEventListener("dragover", dragOver);
    status.addEventListener("dragenter", dragEnter);
    status.addEventListener("dragleave", dragLeave);
    status.addEventListener("drop", dragDrop);
});

function dragOver(e) {
    e.preventDefault();
    //   console.log("dragOver");
}

function dragEnter() {
    this.style.border = "3px dashed #FD8A8A";
    console.log("dragEnter");
}

function dragLeave() {
    this.style.border = "none";
    console.log("dragLeave");
}

function dragDrop() {
    this.style.border = "none";
    this.appendChild(draggableTodo);
    console.log("dropped");
}

/* modal */
const btns = document.querySelectorAll("[data-target-modal]");
const close_modals = document.querySelectorAll(".close-modal");
const overlay = document.getElementById("overlay");

btns.forEach((btn) => {
    btn.addEventListener("click", () => {
        document.querySelector(btn.dataset.targetModal).classList.add("active");
        overlay.classList.add("active");
    });
});

close_modals.forEach((btn) => {
    btn.addEventListener("click", () => {
        const modal = btn.closest(".modal");
        modal.classList.remove("active");
        overlay.classList.remove("active");
    });
});

window.onclick = (event) => {
    if (event.target == overlay) {
        const modals = document.querySelectorAll(".modal");
        modals.forEach((modal) => modal.classList.remove("active"));
        overlay.classList.remove("active");
    }
};

/* create todo  */
const todo_submit = document.getElementById("todo_submit");

todo_submit.addEventListener("click", createTodo);

function createTodo() {
    const todo_div = document.createElement("div");
    const input_val = document.getElementById("todo_input").value;
    const txt = document.createTextNode(input_val);
    const decortion = document.getElementById("todo_input_1").value;
    let selector = document.getElementById("myselect").value;
    console.log(selector);
    if (selector == "معمولی") {
        todo_div.style.backgroundColor = "#4caf50";
    }
    if (selector == "فوری") {
        todo_div.style.backgroundColor = "#F39C12";
    }
    if (selector == "اضطراری") {
        todo_div.style.backgroundColor = "#e6177e";
    }
    todo_div.appendChild(txt);
    todo_div.classList.add("todo");
    todo_div.setAttribute("draggable", "true");

    todo_div.title = decortion;
    /* create span */
    const span = document.createElement("span");
    const span_txt = document.createTextNode("\u00D7");
    span.classList.add("close");
    span.appendChild(span_txt);

    todo_div.appendChild(span);

    no_status.appendChild(todo_div);

    span.addEventListener("click", () => {
        span.parentElement.style.display = "none";
    });
    //   console.log(todo_div);
    todo_form
    todo_div.addEventListener("dragstart", dragStart);
    todo_div.addEventListener("dragend", dragEnd);

    document.getElementById("todo_input").value = "";
    document.getElementById("todo_input_1").value = "";
    document.getElementById("nofication_time_1").value = "";
    document.getElementById("nofication_time_2").value = "";
    document.getElementById("myCheck").checked = false;

    todo_form.classList.remove("active");
    overlay.classList.remove("active");
}

// const close_btns = document.querySelectorAll(".close");

close_btns.forEach((btn) => {
    btn.addEventListener("click", () => {
        btn.parentElement.style.display = "none";
    });
});

function myFunction() {
    // Get the checkbox
    var checkBox = document.getElementById("myCheck");
    // Get the output text
    var text1 = document.getElementById("nofication_time_1");
    var text2 = document.getElementById("nofication_time_2");
    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        text1.style.display = "block";
        text2.style.display = "block";
    } else {
        text1.style.display = "none";
        text2.style.display = "none";
    }
};
modeSwitch.addEventListener("click" , () =>{
    body.classList.toggle("dark");
      let st = document.getElementsByClassName("status");
    
    if(body.classList.contains("dark")){
        modeText.innerText = "حالت روز";
        for(i=0;i<st.length;i++){
            st[i].style.backgroundImage="repeating-linear-gradient(-45deg, transparent 0 10px, rgb(0, 0, 0) 10px 20px )"
        }
    }else{
        modeText.innerText = "حالت شب";
        for(i=0;i<st.length;i++){
            st[i].style.backgroundImage="repeating-linear-gradient(-45deg, rgb(0, 191, 255) 0 10px, rgb(0, 0, 0) 10px 15px )"
        }
        //dfl[pfell[s]]
    }
    
});