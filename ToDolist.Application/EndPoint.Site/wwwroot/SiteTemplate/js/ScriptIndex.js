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
    this.style.border = "3px dashed #ccc";
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

 create todo  
const todo_submit = document.getelementbyid("todo_submit");

todo_submit.addeventlistener("click", createtodo);

 function createtodo() {
     const todo_div = document.createelement("div");
     const input_val = document.getelementbyid("todo_input").value;
     const txt = document.createtextnode(input_val);
     const decortion = document.getelementbyid("todo_input_1").value;
     let selector = document.getelementbyid("myselect").value;
     console.log(selector);
     if (selector == "معمولی") {
         todo_div.style.backgroundcolor = "#4caf50";
     }
     if (selector == "فوری") {
         todo_div.style.backgroundcolor = "#f39c12";
     }
     if (selector == "اضطراری") {
         todo_div.style.backgroundcolor = "#e6177e";
     }
     todo_div.appendchild(txt);
     todo_div.classlist.add("todo");
     todo_div.setattribute("draggable", "true");

     todo_div.title = decortion;
     /* create span */
     const span = document.createelement("span");
     const span_txt = document.createtextnode("\u00d7");
     span.classlist.add("close");
     span.appendchild(span_txt);

     todo_div.appendchild(span);

     no_status.appendchild(todo_div);

     span.addeventlistener("click", () => {
         span.parentelement.style.display = "none";
     });
     //   console.log(todo_div);
     todo_form
     todo_div.addeventlistener("dragstart", dragstart);
     todo_div.addeventlistener("dragend", dragend);

     document.getelementbyid("todo_input").value = "";
     document.getelementbyid("todo_input_1").value = "";
     document.getelementbyid("nofication_time_1").value = "";
     document.getelementbyid("nofication_time_2").value = "";
     document.getelementbyid("mycheck").checked = false;

     todo_form.classlist.remove("active");
     overlay.classlist.remove("active");
 }

const close_btns = document.queryselectorall(".close");

close_btns.foreach((btn) => {
    btn.addeventlistener("click", () => {
        btn.parentelement.style.display = "none";
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

