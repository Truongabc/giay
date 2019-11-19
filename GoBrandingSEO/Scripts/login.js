var user_lg = 'truong';
var pass_lg = '123';

var iuser = document.getElementById('user');
var ipass = document.getElementById('pass');

var fmlogin = document.getElementById('lg_fm');

if (fmlogin.attachEvent) {
    fmlogin.attachEvent('sumit', onSumit);
} else {
    fmlogin.addEventListener('sumit', onSumit);
}
function onSumit(e) {
    var user = iuser.value;
    var pass = ipass.value;

    if (user == user_lg && pass == pass_lg) {
        alert('Đăng Nhâp Thành công');
    }
    else {
        alert('Đăng nhập thất bại!');
    }
}
