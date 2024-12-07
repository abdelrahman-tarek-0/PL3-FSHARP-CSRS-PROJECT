namespace CSRS

open System
open System.Drawing
open System.Windows.Forms

module OrderSeat =
    let initForm (seat: int) (onClickOrder: Boolean -> unit) =
        let form = new Form(Text = "Order Seat", Size = Size(500, 250))

        let label =
            new Label(
                Text = $"You have selected seat {seat}.",
                Width = 250,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12.0F, FontStyle.Bold),
                Top = 50,
                Left = 125
            )


        let confirmBtn =
            new Button(
                Text = "Order",
                Top = 100,
                Left = 125,
                Width = 100,
                Height = 40,
                Font = new Font("Arial", 12.0F, FontStyle.Bold)
            )

        confirmBtn.Click.Add(fun _ -> onClickOrder true)

        let cancelBtn =
            new Button(
                Text = "Cancel",
                Top = 100,
                Left = 275,
                Width = 100,
                Height = 40,
                Font = new Font("Arial", 12.0F, FontStyle.Bold)
            )

        cancelBtn.Click.Add(fun _ -> onClickOrder false)

        form.Controls.Add(label)
        form.Controls.Add(confirmBtn)
        form.Controls.Add(cancelBtn)

        form