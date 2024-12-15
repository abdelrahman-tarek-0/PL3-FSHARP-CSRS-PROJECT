namespace CSRS

open System
open System.Drawing
open System.Windows.Forms

module LoginForm =

    let initForm onClickHandler =
        
        let form = 
            new Form(
                Text = "Login Form", 
                Width = 400, 
                Height = 250, 
                StartPosition = FormStartPosition.CenterScreen
            )

        
        let lblUsername = 
            new Label(
                Text = "Username:", 
                Width = 200, 
                Height = 30, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Font = new Font("Arial", 12.0F, FontStyle.Bold), 
                Top = 50, 
                Left = 100
            )

        
        let txtUsername = 
            new TextBox(
                Width = 200, 
                Height = 30, 
                Font = new Font("Arial", 12.0F, FontStyle.Regular), 
                Top = 90, 
                Left = 100
            )

        
        let btnLogin = 
            new Button(
                Text = "Login", 
                Width = 100, 
                Height = 40, 
                Font = new Font("Arial", 12.0F, FontStyle.Bold), 
                Top = 140, 
                Left = 150
            )

        
        btnLogin.Click.Add(fun _ ->
            match txtUsername.Text.Trim() with
            | "" -> 
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            | username -> 
                onClickHandler username
                form.Hide()
        )

        
        form.Controls.AddRange([| lblUsername; txtUsername; btnLogin |])

        
        form