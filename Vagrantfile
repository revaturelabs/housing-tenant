Vagrant.configure("2") do |config|
  # box configuration.
  config.vm.box = "ubuntu/xenial64"
  config.vm.box_check_update = false
  config.vm.box_version = "20170710.0.0"

  # network configuration.
  config.vm.network "forwarded_port", guest: 8000, host: 8000, host_ip: "127.0.0.1"
  config.vm.network "forwarded_port", guest: 8100, host: 8100, host_ip: "127.0.0.1"
  config.vm.network "forwarded_port", guest: 8200, host: 8200, host_ip: "127.0.0.1"

  # provider configuration.
  config.vm.provider "virtualbox" do |vb|
    vb.gui = false
    vb.memory = "1024"
  end

  # provision configuration.
  config.vm.provision "shell", path: "vagrant.sh"
end
