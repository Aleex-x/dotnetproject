using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MvcMovie.Controllers {
  public class ByeWorld : Controller {
    public string Welcome (string name, int numTimes = 1) {
      Usuario usuario = new Usuario ();

      usuario.user = "Alex";
      usuario.pass = "123";
      usuario.idUsuario = 1;

      return HtmlEncoder.Default.Encode ("{ nombre: alex }");

    }

    public List<Usuario> GetPlayers (string var) {
      Console.WriteLine (var);
      Console.WriteLine ("HOLA A TODOS XD");
      List<Usuario> players = new List<Usuario> ();

      players.Add (new Usuario {
        user = var, pass = "Manning", idUsuario = 35
      });
      players.Add (new Usuario {
        user = "Drew", pass = "Brees", idUsuario = 31
      });
      players.Add (new Usuario {
        user = "Brett", pass = "Favre", idUsuario = 58
      });

      return players;
    }
    public List<Usuario> getAlumnos (string id) {
      string cCon = "Server=127.0.0.1;UserID=root;Database=ejemplo;";

      List<Usuario> players = new List<Usuario> ();

      using (var con = new MySqlConnection (cCon)) {
        con.Open ();
        using (var cmd = new MySqlCommand ("SELECT * FROM alumnos", con)) {
          using (var reader = cmd.ExecuteReader ()) {
            try {
              while (reader.Read ()) {
                players.Add (new Usuario {
                  idUsuario = reader.GetInt16 (0),
                    user = reader.GetString (1),
                    pass = reader.GetString (2),
                });
              }
            } finally {
              reader.Close ();
              con.Close ();
            }
          }
        }
      }

      return players;
    }

    public Boolean saveAlumno (string name, string pass) {
      string cCon = "Server=127.0.0.1;UserID=root;Database=ejemplo;";

      Boolean res = false;

      using (var con = new MySqlConnection (cCon)) {
        con.Open ();
        using (var cmd = new MySqlCommand (
          "INSERT INTO alumnos(name, pass) VALUES ('" + name + "', '" + pass + "')",
          con
        )) {
          using (var reader = cmd.ExecuteReader ()) {
            if (reader.RecordsAffected == 1) res = true;
            reader.Close ();
            con.Close ();
          }
        }
      }
    
      return res;
    }
    
    public Boolean deleteAlumno(string id) {
      string cCon = "Server=127.0.0.1;UserID=root;Database=ejemplo;";

      Boolean res = false;

      using (var con = new MySqlConnection (cCon)) {
        con.Open ();
        using (var cmd = new MySqlCommand (
          "DELETE FROM alumnos WHERE id = '" +id+"'",
          con
        )) {
          using (var reader = cmd.ExecuteReader ()) {
            if (reader.RecordsAffected == 1) res = true;
            reader.Close ();
            con.Close ();
          }
        }
      }

      return res;
    }
  }
}