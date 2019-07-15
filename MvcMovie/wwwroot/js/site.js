// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = () => {
  $.ajax({
    url: '/byeworld/GetPlayers',
    method: 'POST',
    data: {
      var: 'JESUCRISTOOOOOOOOOOOOOO',
    },
    success: (data) => {
      console.log('success');
      if (!!data) {
        data.forEach(({user, pass, id}, index) => {
          $(`.row .col-sm:nth-child(${index + 1})`).html(user);
        });
      }
    },
    error: (data) => {
      console.log('error');
      console.log(data);
    },
  });
}