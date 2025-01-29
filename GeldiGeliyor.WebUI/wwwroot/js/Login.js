
const adminBtn = document.getElementById("adminBtn");
const userBtn = document.getElementById("userBtn");
const adminForm = document.getElementById("adminForm");
const userForm = document.getElementById("userForm");
const registerBtnContainer = document.querySelector(".register-btn");
const loginLbl = document.getElementById("login-lbl");
const registerLbl = document.getElementById("register-lbl");

loginLbl.addEventListener("click", function () {
    adminBtn.style.display = "none";
    userBtn.style.display = "none";
});
registerLbl.addEventListener("click", function () {
    adminBtn.style.display = "block";
    userBtn.style.display = "block";
})
// Admin butonuna tıklandığında
adminBtn.addEventListener("click", function () {
    adminForm.style.display = "block";  // Admin formunu göster
    userForm.style.display = "none";    // Kullanıcı formunu gizle
    registerBtnContainer.classList.add("shrink"); // Butonları küçült
    userBtn.style.backgroundColor = "";
    adminBtn.style.backgroundColor = "#423189";
    userBtn.style.transition = "background-color 0.9s ease";

});
// Kullanıcı butonuna tıklandığında
userBtn.addEventListener("click", function () {
    userForm.style.display = "block";  // Kullanıcı formunu göster
    adminForm.style.display = "none";  // Admin formunu gizle
    registerBtnContainer.classList.add("shrink"); // Butonları küçült
    userBtn.style.backgroundColor = "#423189";
    adminBtn.style.backgroundColor = "";
    adminBtn.style.transition = "background-color 0.9s ease";
});