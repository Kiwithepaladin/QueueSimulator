VAR isInternetFixed = false
VAR isFoodOrdered = false
-> Start

== Start ==
    - <b> Who would you like to call? <b>
        *<i> <b>Call ISP <b> <i>
            -> TalkWithISP
        *<I> <b> Order Food <b> <i>
            -> TalkWithRestaurant
        
== TalkWithISP ==
- Hello this is Jacob how may I Assist you?
       * Hey there is an issue with my Internet.
     What seems to be the issue?
        **Its barely moving!.
        -> DONE
        **I'm losing connection rapidly.
             I sorted that for you
              ~ isInternetFixed = true
                *** Thanks Jacob.
                    -> PhoneCallOver
        **Its beyond saving, Goodbye.
            -> PhoneCallOver
 * My Ping is too high
    ** What Should I do?
    -> PhoneCallOver
== TalkWithRestaurant == 
- Hello this is Arjun speaking, What would you like to order today?
    *I would like to order 
    -> DONE
== PhoneCallOver ==
- Phone call is over.
    -> END
    
