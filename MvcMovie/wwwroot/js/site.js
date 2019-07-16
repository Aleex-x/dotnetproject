handleSubmit = () => {
  $.ajax({
    url: '/byeworld/saveAlumno',
    method: 'POST',
    data: {
      name: $('#name').val(),
      pass: $('#pass').val(),
    },
    success: (data) => {
      location.reload();
      console.log('success');
      console.log(data);
    },
    error: (data) => {
      console.log('error');
      console.log(data);
    },
  });
}

deleteStuff = (id) => {
  $.ajax({
    url: '/byeworld/deleteAlumno',
    method: 'POST',
    data: {
      id,
    },
    success: (data) => {
      location.reload();
      console.log('success');
      console.log(data);
    },
    error: (data) => {
      console.log('error');
      console.log(data);
    },
  });
}

window.onload = () => {
  $.ajax({
    url: '/byeworld/getAlumnos',
    method: 'POST',
    data: {
      var: '',
    },
    success: (data) => {
      if (!!data) {
        data.forEach(({user, pass, idUsuario}, index) => {
          $('.table--body').append(`
            <tr>
              <th scope = "row" >${idUsuario}</th>
              <td>${user}</td>
              <td>${pass}</td>
              <td><a hred="#" style="cursor: pointer; color: blue;" onclick="deleteStuff(${idUsuario});">Delete!</a></td>
            </tr>`
          );
        });
      }

    },
    error: (data) => {
      console.log('error');
      console.log(data);
    },
  });
}