open System
open System.Windows.Forms

[<EntryPoint>]
let main argv = 

    let form = new Form(Text = "F#-SUCKS", Width = 400, Height = 300)

    let label = new Label(Text = "Hello world", AutoSize=true, Top = 100, Left = 150)

    form.Controls.Add(label)

    Application.Run(form)

    0

