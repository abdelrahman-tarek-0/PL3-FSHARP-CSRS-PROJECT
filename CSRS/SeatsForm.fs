namespace CSRS

open System
open System.Drawing
open System.Windows.Forms

open CSRS

module SeatsForm =
    let initForm (onSeatClick) =
        let form = new Form(Text = "Seats", Width = 800, Height = 600)

        let label =
            new Label(
                Text = "Book a seat",
                Width = 200,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12.0F, FontStyle.Bold),
                Top = 10,
                Left = 300
            )

        let mutable btns = []

        let addBtn (btn) =
            form.Controls.Add(btn)
            btns <- btn :: btns

        let destroyBtns () =
            for btn in btns do
                form.Controls.Remove(btn)

            btns <- []

  

        let rec renderSeats () =
            destroyBtns ()
            let mutable x = 50
            let mutable y = 50
            let mutable i = 0

            printfn "Rendering seats"

            for (seat, status) in SeatsStore.getSeats () do
                printfn "Rendering seat %d" seat
                let btnSeat =
                    new Button(
                        Text = string seat,
                        Width = 50,
                        Height = 50,
                        Font = new Font("Arial", 12.0F, FontStyle.Bold),
                        Top = y,
                        Left = x
                    )



                if (status = SeatsStore.SeatStatus.R) then
                    btnSeat.Enabled <- false


                let seatAction (e) = 
                    onSeatClick seat
                    renderSeats ()

                form.Controls.Add(label)
                btnSeat.Click.Add(seatAction)

                addBtn btnSeat

                i <- i + 1
                x <- x + 60

                if i % 10 = 0 then
                    x <- 50
                    y <- y + 60

        renderSeats ()
        form
