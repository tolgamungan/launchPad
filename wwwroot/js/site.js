function startAutoLogout() {
    // setup timeout that will occur when session has expired (20 minutes = 60000 * 20 milliseconds)
    window.setTimeout(() => document.location = "/", 1200000);
    // setup timeout that will occur when session about to expire to warn user
    window.setTimeout(() => document.getElementById("lblExpire").innerHTML = "WARNING : Session is about to expire!", 1080000);
    window.setTimeout(() => document.getElementById("postback").style.display="block", 1080000);
}