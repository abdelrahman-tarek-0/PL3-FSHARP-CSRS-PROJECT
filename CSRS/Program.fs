open System
open System.Drawing
open System.Windows.Forms
open System.IO

open Utils

let LoginForm onClickHandler =
    let form = new Form(Text = "Login Form", Width = 400, Height = 250)
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
        new TextBox(Width = 200, Height = 30, Font = new Font("Arial", 12.0F, FontStyle.Regular), Top = 90, Left = 100)

    let btnLogin =
        new Button(
            Text = "Login",
            Width = 100,
            Height = 40,
            Font = new Font("Arial", 12.0F, FontStyle.Bold),
            Top = 140,
            Left = 150
        )

    let loginAction _ =
        if String.IsNullOrWhiteSpace(txtUsername.Text) then
            MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            |> ignore
        else
            onClickHandler txtUsername.Text
            form.Close()

    form.Controls.AddRange([| lblUsername; txtUsername; btnLogin |])
    btnLogin.Click.Add(loginAction)
    form


// Run the LoginForm
[<EntryPoint>]
let main _ =

    Application.EnableVisualStyles()
    let form = LoginForm (fun username -> 

        MessageBox.Show($"Welcome, {username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
        |> ignore
    )
    Application.Run(form)

    0
