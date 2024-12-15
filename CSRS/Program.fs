open System
open System.Drawing
open System.Windows.Forms
open System.IO

open CSRS

[<EntryPoint>]
let main _ =
    Application.EnableVisualStyles()

    let form =
        LoginForm.initForm (fun username ->
            MessageBox.Show(
                $"Welcome, {username}!", 
                "Welcome", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            ) |> ignore

            TicketFile.delete ()

            let rec onOrderClick (seat: int) (order: bool) (username: string) =
                match order with
                | true -> 
                    MessageBox.Show(
                        $"You have successfully ordered seat {seat}.",
                        "Order Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    ) |> ignore

                    TicketFile.openFileInDefaultProgram (TicketFile.SaveTicket(seat, username)) |> ignore

                    printfn "Ticket saved to %s" (TicketFile.SaveTicket(seat, username))

                    SeatsStore.editSeatStatus seat SeatsStore.SeatStatus.R |> ignore

            let rec onSeatClick (form: Form) (seat) =
                form.Hide()

                let rec orderSeatForm =
                    OrderSeat.initForm seat (fun order ->
                        onOrderClick seat order
                        SeatsForm.rerenderSeats form (onSeatClick form)

                        form.Show()
                        orderSeatForm.Hide()
                    )

                orderSeatForm.Show()

            let rec seatsForm = SeatsForm.initForm (fun seat -> onSeatClick seatsForm seat)

            seatsForm.Show()
        )

    Application.Run(form)

    0
