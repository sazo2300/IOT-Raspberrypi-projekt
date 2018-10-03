
import _thread
import time
import smbus
import socket
import sys

UDP_IP = "192.168.137.12"
UDP_PORT = 5005
bus = smbus.SMBus(1)
MESSAGE = "Hello, World!"

if len(sys.argv) >= 3:
        UDP_IP = sys.argv[1]
        UDP_PORT = sys.argv[2]
        MESSAGE = sys.argv[3]

print ("UDP target IP:", UDP_IP)
print ("UDP target port:", UDP_PORT)
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#sock.setsockopt(SO_SOCKET, SO_BROADCAST, 1)
sock.bind((UDP_IP, UDP_PORT))
running = True
delay = 0.5

# Define a function for the thread
def print_message():
        while True:
                if (running == True):
                        bus.write_byte(0x48, 0x00)
                        bus.read_byte(0x48)
                        reading = bus.read_byte(0x48)
                        bus.write_byte(0x48, 0x01)
                        bus.read_byte(0x48)
						reading2 = bus.read_byte(0x48)
                        global delay
                        time.sleep(delay)
                        print("Lysdata: " + str(reading))
                        print("Tempdata: " + str(reading2))
                        formatedData = "Lysdata: " + str(reading) + "\nTempdata: " + str(reading2)
                        sock.sendto(bytes((formatedData),'UTF-8'), (UDP_IP, UDP_PORT))

def change_delay():
        time.sleep(3)
        global delay

        while True:
                data, addr = sock.recvfrom(1024) # buffer size is 1024 bytes
                print ("received message:", data)
                splitext = data.split()
                print (splitext)
                print (str(splitext[1]))
                if (splitext[1]) == bytes("delay", 'UTF-8'):
                        delay = float(splitext[2])
                        print ("Skifter delay")

try:
        _thread.start_new_thread( print_message, () )
#        _thread.start_new_thread( change_delay, () )
except:
        print ("Error: unable to start thread")
# endles do nothing - while other threads are working
while True:
        pass



