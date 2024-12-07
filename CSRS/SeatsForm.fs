namespace CSRS

open System
open System.Drawing
open System.Windows.Forms

open CSRS

module SeatsForm =
    let mutable btns = []

    let addBtn (form: Form) (btn) =
        printfn "Adding button"
        form.Controls.Add(btn)
        btns <- btn :: btns

    let destroyBtns (form: Form) =
        for btn in btns do
            form.Controls.Remove(btn)

        btns <- []


    let rec rerenderSeats (form: Form) (onSeatClick) =
            destroyBtns (form)

            let mutable x = 20
            let mutable y = 20
            let mutable i = 0

            printfn "Rendering seats"

            for (seat, status) in SeatsStore.getSeats () do
                printfn "Rendering seat %d" seat

                let btnSeat =
                    new Button(
                        Text = string seat,
                        Font = new Font("Arial", 12.0F, FontStyle.Bold),
                        Top = y,
                        Left = x,
                        TextAlign = ContentAlignment.TopLeft,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Size = Size(130, 130)
                    )


                if (status = SeatsStore.SeatStatus.A) then
                    btnSeat.BackgroundImage <- Image.FromFile(@"..\..\..\..\open.png") // تأكد من المسار الصحيح للصورة
                else
                    btnSeat.BackgroundImage <- Image.FromFile(@"..\..\..\..\close.png") // تأكد من المسار الصحيح للصورة


                if (status = SeatsStore.SeatStatus.R) then
                    btnSeat.Enabled <- false


                let seatAction (e) =
                    onSeatClick seat
                    rerenderSeats form onSeatClick

                btnSeat.Click.Add(seatAction)
                addBtn form btnSeat

                i <- i + 1
                x <- x + 140

                if i % 4 = 0 then
                    x <- 20
                    y <- y + 140
    let initForm (onSeatClick) =
        let form = new Form(Text = "Seats", Size = Size(720, 600))
        rerenderSeats form onSeatClick
        form
