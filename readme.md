# TCP vs UDP

## TCP: 

- Transmission Control Protocol
- The communication between two computers needs to be “good” and reliable, to guarantee that the data is received correctly and in order.
- Connection oriented protocol - which means it must first acknowledge a session between the two computers that are communicating.
- The two computers verify a connection doing a 3-way handshake.
- TCP guarantees the delivery of the data - so if a data packet is lost and doesn’t arrive, then TCP will resend it.

## UDP:

- User Datagram Protocol
- Similar to TCP in that it is a protocol for sending and receiving that, but the main difference is that UDP is connection-less, which means it doesn’t establish a session and it does not guarantee data delivery.
- Sends data and doesn’t care what happens to it.
- Because of the less overhead that is involved in not guaranteeing data delivery, UDP is faster than TCP.

Unlike TCP, UDP does not establish a persistent connection. Each message is sent individually without any handshake, and there is no guarantee of delivery.
