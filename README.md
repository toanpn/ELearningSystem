# Project môn học Thiết Kế Xây Dựng Hệ thống
## Nhóm thực hiện:
- Phạm Tiến Nam
- Nguyễn Huy Thành
- Lê Đức Thanh
- Phạm Ngọc Toàn
- Nguyễn Công Sỹ
- Đỗ Khắc Chung
## Cấu trúc thư mục:
- Web API: sử dụng Web API để tạo REST API
- Client:
    - Dashboard: client trang quản trị
    - Home: client trang chủ người dùng
## Cách push code:
- Khi thêm một chức năng mới: <b>Checkout ra một branch mới có định dạng features/<tên branch></b> để gom nhóm các features vào 1 folder git
- Muốn Merge code: merge từ develop -> branch muốn merge, sửa conflict rồi merge ngược lại develop. <b>Không merge trực tiếp vào develop nếu không chắc chắn</b>.
- Cú pháp message commit code: <b>ACTION: TIME AUTHOR message</b>
    - ACTION: Bao gồm: Update/Add/Delete...
    - TIME: Thời gian ngày commit, ví dụ: 15/10/2019
    - AUTHOR: Tên người commit, nên viết dạng Tên_Họ, ví dụ: NamPT
    - Message: Message commit, rõ ràng ý nghĩa
## Cách chạy:
- Chạy API: Open solution trong thư mục WebAPI với Visual Studio, F5 để chạy API
- Chạy Client: 
    - CD vào thư mục /client
    - CD vào /dashboard hoặc /home
    - Chạy ng serve --port=xxxx -o (xxxx là cổng port). Nên config xxxx để tránh trùng port giữa 2 client và các process khác trong môi trường lập trình.