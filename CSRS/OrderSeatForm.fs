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

        form