from locust import HttpLocust, TaskSet


def index(l):
    l.client.get("/")

def gm4g(l):
    l.client.get('tr/urunler/GM4G')

def add_to_basket(l):
    l.client.post('/tr/urunler/aksesuarlar', { 'SelectedProductId': '33CA4B0C33FD9628', 'submit': 'AddToBasket'})


class HomeBehavior(TaskSet):
    tasks = {
        index: 1,
        gm4g: 0,
        add_to_basket: 0
    }

class WebsiteUser(HttpLocust):
    task_set = HomeBehavior
    min_wait = 5000
    max_wait = 9000