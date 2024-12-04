namespace CSRS


module SeatsStore =
    type SeatStatus =
        | A
        | R

    let mutable seats =
        [ (1, SeatStatus.A)
          (2, SeatStatus.A)
          (3, SeatStatus.A)
          (4, SeatStatus.A)
          (5, SeatStatus.A) ]

    let editSeatStatus seat status =
        seats <- seats |> List.map (fun (s, st) -> if s = seat then (s, status) else (s, st))
        seats

    let getSeats () = seats


