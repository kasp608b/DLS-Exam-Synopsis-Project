import requests, json, time
from apscheduler.schedulers.blocking import BlockingScheduler as scheduler

request_count = 0

def send_request():
    global request_count
    url = 'http://localhost:31003/api/Books'
    # Header
    headers = {'Content-Type': 'application/json'}
    # Sending GET request
    try:
        request = requests.get(url, headers=headers)
        request_count += 1
        print(f"Request count: {request_count}")
    except (requests.Timeout, requests.ConnectionError, requests.HTTPError) as err:
        print("Error while trying to GET books data")
        print(err)
    finally:
        request.close()
    print(request.content)
    return request.content

if __name__ == '__main__':
    sched = scheduler()
    print(time.time())
    sched.add_job(send_request, 'interval', seconds=0.00001)
    sched.start()
