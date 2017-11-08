using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clue.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Principal_Click(object sender, EventArgs e)
        {
            frame_paginas.Attributes.Add("src", "../Views/Principal.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            frame_paginas.Attributes.Add("src", "../Views/Login.aspx");
        }

        protected void Perfil_Click(object sender, EventArgs e)
        {
            frame_paginas.Attributes.Add("src", "../Views/PerfilUsuario.aspx");
        }
    }
}