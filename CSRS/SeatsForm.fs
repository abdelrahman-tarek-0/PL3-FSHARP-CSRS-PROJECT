namespace CSRS

open System
open System.Drawing
open System.Windows.Forms

module SeatsForm =

    type SeatStatus = 
        | Available
        | Reserved

    let rows = 5
    let cols = 5

    let mutable seatStatus = Array2D.init rows cols (fun _ _ -> Available)

    let toggleSeatStatus (row: int) (col: int) (button: Button) =
        if seatStatus.[row, col] = Available then
            seatStatus.[row, col] <- Reserved
            button.BackgroundImage <- Image.FromFile(@"E:\Projects\Project PL3\PL3-FSHARP-CSRS-PROJECT\close.png") // المسار للصورة عند الحجز
            button.Enabled <- false
        else
            seatStatus.[row, col] <- Available
            button.BackgroundImage <- Image.FromFile(@"E:\Projects\Project PL3\PL3-FSHARP-CSRS-PROJECT\open.png") // المسار للصورة عند إتاحة المقعد
            button.Enabled <- true

    let createForm (onSeatClick: int -> unit) =
        let form = new Form(Text = "Seats", Size = Size(720, 600))

        let mutable seatNumber = 1 

        for row in 0..rows-1 do
            for col in 0..cols-1 do
                let button = new Button()
                button.Size <- Size(130, 130)
                button.Location <- Point(140 * col, 140 * row)
                button.Text <- seatNumber.ToString()
                button.TextAlign <- ContentAlignment.TopLeft
                button.BackgroundImage <- Image.FromFile(@"E:\Projects\Project PL3\PL3-FSHARP-CSRS-PROJECT\open.png") // تأكد من المسار الصحيح للصورة
                button.BackgroundImageLayout <- ImageLayout.Stretch

                button.Click.Add(fun _ -> 
                   toggleSeatStatus row col button 
                   let seatNumberClicked = int button.Text
                   onSeatClick seatNumberClicked  
                )
                form.Controls.Add(button)

                seatNumber <- seatNumber + 1 

        form
