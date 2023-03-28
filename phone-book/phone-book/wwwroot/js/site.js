function profileFunction() {
    document.getElementById("profile-content").classList.toggle("show");
}

window.onclick = function (event) {
    if (!event.target.matches('.header-profile-button')) {

        var dropdowns = document.getElementsByClassName("header-profile-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}