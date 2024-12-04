open System
open System.Drawing
open System.Windows.Forms
open System.IO

open CSRS



// Run the LoginForm
[<EntryPoint>]
let main _ =

    Application.EnableVisualStyles()
    let form = LoginForm.initForm(fun username -> 
        MessageBox.Show($"Welcome, {username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
        |> ignore
    )
    Application.Run(form)

    0
