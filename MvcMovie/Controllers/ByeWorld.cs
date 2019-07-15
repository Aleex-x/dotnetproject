using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using System;

namespace MvcMovie.Controllers {
  public class ByeWorld: Controller {
    public string Welcome(string name, int numTimes = 1) {
      Usuario usuario = new Usuario();

      usuario.user = "Alex";
      usuario.pass = "123";
      usuario.idUsuario = 1;

      return HtmlEncoder.Default.Encode("{ nombre: alex }");

    }

    public List<Usuario> GetPlayers(string var) {
      Console.WriteLine(var);
      Console.WriteLine("HOLA A TODOS XD");
      List<Usuario> players = new List <Usuario> ();

      players.Add(new Usuario {
        user = var, pass = "Manning", idUsuario = 35
      });
      players.Add(new Usuario {
        user = "Drew", pass = "Brees", idUsuario = 31
      });
      players.Add(new Usuario {
        user = "Brett", pass = "Favre", idUsuario = 58
      });

      return players;
    }
  }
}